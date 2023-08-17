import {
  ChangeDetectorRef,
  Component,
  NgZone,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormArray,
  FormControl,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { CustomFormService } from '../custom-form.service';
import { ItemModel } from '../models/custom-form-item-model';
import { FormField } from '../models/custom-form-model';
import { NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import {
  ColDef,
  FirstDataRenderedEvent,
  GridOptions,
  GridReadyEvent,
  RowClickedEvent,
} from 'ag-grid-community';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-custom-form',
  templateUrl: './custom-form.component.html',
  styleUrls: ['./custom-form.component.css'],
})
export class CustomFormComponent implements OnInit {
  @ViewChild('content', { static: true }) content!: TemplateRef<any>;
  formNameDisplay = 'none';
  display = 'none';

  customForm!: FormGroup;
  formFields: ItemModel[] = [];
  customFieldForm!: FormGroup;
  formNameForm!: FormGroup;
  showSuccessMessage: boolean = false;
  showItemSuccessMessage: boolean = false;

  rowData$!: FormField[];

  columnDefs: ColDef[] = [{ field: 'formName', headerName: 'FormName' }];

  defaultColDef: ColDef = {
    sortable: true,
    filter: true,
    resizable: true,
  };

  onFirstDataRendered(params: FirstDataRenderedEvent) {
    params.api.sizeColumnsToFit();
  }

  gridOptions: GridOptions = {
    onRowClicked: this.onRowClicked.bind(this),
    domLayout: 'normal',
  };

  onGridReady(params: GridReadyEvent) {}

  onRowClicked(event: RowClickedEvent) {
    const rowData = event.data;

    this.openEnd(this.content, rowData);
  }

  constructor(
    private formBuilder: FormBuilder,
    private customFormService: CustomFormService,
    private offcanvasService: NgbOffcanvas,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.initializeForm();
    this.initializeCustomFieldForm();
    this.initializeFormNameForm();
    this.loadData();
  }

  loadData() {
    this.customFormService.getAll().subscribe(
      (response: FormField[]) => {
        this.rowData$ = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  initializeForm() {
    this.customForm = this.formBuilder.group({
      customFormFieldId: [''],
      formName: [''],
      customFields: this.formBuilder.array([]),
    });
  }

  get customFields() {
    return this.customForm.get('customFields') as FormArray;
  }

  getFieldControl(index: number): FormControl {
    return this.customFields.at(index) as FormControl;
  }

  initializeCustomFieldForm() {
    this.customFieldForm = this.formBuilder.group({
      customFormFieldItemId: [''],
      type: ['', Validators.required],
      label: ['', Validators.required],
      options: ['', Validators.required],
      data: ['', Validators.required],
    });
  }

  initializeFormNameForm() {
    this.formNameForm = this.formBuilder.group({
      formName: ['', Validators.required],
    });
  }

  addFormName() {
    if (this.formNameForm.valid) {
      const formName = this.formNameForm.get('formName')?.value;
      this.customForm.patchValue({ formName });
      this.formNameDisplay = 'none';
    }
  }

  addCustomField() {
    if (this.customFieldForm.get('type')?.invalid) {
      this.customFieldForm.get('type')?.markAsTouched();
      return;
    }

    if (this.isDropdownOrChoice()) {
      const optionsValue = this.customFieldForm.get('options')?.value;

      if (!optionsValue || !optionsValue.includes(',')) {
        this.customFieldForm.setErrors({ commaSeparated: true });
        return;
      }
    }
    var item = this.customFieldForm.value;
    const type = (item && item.type) || 'text';
    const label = item?.label || '';
    const options = (item?.options && item.options.split(',')) || [];
    const data = item?.data || '';
    const customFormFieldItemId = item?.customFormFieldItemId || '';

    const controlName = `customField${this.formFields.length + 1}`;

    const newField: ItemModel = {
      customFormFieldItemId,
      type,
      label,
      controlName,
      options: type === 'dropdown' || type === 'choice' ? options : [],
      data,
      index: this.formFields.length,
    };

    this.formFields.push(newField);
    this.customFields.push(this.formBuilder.control(null, Validators.required));

    this.customFieldForm.reset();
  }

  onSubmit() {
    if (this.customForm.valid) {
      const formName = this.customForm.get('formName')?.value;

      var customFormFieldId;
      var formData: FormField;

      if (this.customForm.get('customFormFieldId')?.value) {
        customFormFieldId = this.customForm.get('customFormFieldId')?.value;

        const items: ItemModel[] = this.formFields.map((field, i) => {
          const item: ItemModel = {
            ...(field.customFormFieldItemId
              ? { customFormFieldItemId: field.customFormFieldItemId }
              : {}),
            type: field.type,
            label: field.label,
            controlName: field.controlName,
            option: field.options !== undefined ? field.options.join(',') : '',
            data: this.customFields.controls[i].value || '',
            index: field.index,
          };

          return item;
        });

        formData = {
          customFormFieldId: customFormFieldId,
          formName: formName,
          customFormFieldItems: items,
        };
      } else {
        const items: ItemModel[] = this.formFields.map((field, i) => {
          const item: ItemModel = {
            type: field.type,
            label: field.label,
            controlName: field.controlName,
            option: field.options !== undefined ? field.options.join(',') : '',
            data: this.customFields.controls[i].value || '',
            index: field.index,
          };

          return item;
        });
        formData = {
          formName: formName,
          customFormFieldItems: items,
        };
      }

      console.log(formData);

      this.customFormService.addFormField(formData).subscribe(
        (response) => {
          const existingIndex = this.rowData$.findIndex(
            (field) => field.customFormFieldId === response.customFormFieldId
          );

          if (existingIndex === -1) {
            this.rowData$ = [...this.rowData$, response];
          } else {
            this.rowData$ = [
              ...this.rowData$.slice(0, existingIndex),
              response,
              ...this.rowData$.slice(existingIndex + 1),
            ];
          }
          
          this.showSuccessMessage = true;

          setTimeout(() => {
            this.showSuccessMessage = false;
          }, 2000);
        },
        (error) => {
          this.cdr.markForCheck();
          console.log('Error adding form fields:', error);
        }
      );
    } else {
      console.log('Invalid form');
    }
  }

  openItemModal() {
    this.display = 'block';
  }

  openFormNameModal() {
    this.formNameDisplay = 'block';
  }

  onCloseFormNameModal() {
    this.formNameDisplay = 'none';
  }

  onCloseHandled() {
    this.display = 'none';
    this.customFieldForm.reset();
  }

  isDropdownOrChoice() {
    const type = this.customFieldForm.get('type')?.value;
    return type === 'dropdown' || type === 'choice';
  }

  openEnd(content: TemplateRef<any>, rowData: FormField) {
    this.formFields = [];
    this.customFields.clear();

    this.customForm.get('formName')?.setValue(rowData.formName);
    this.customForm
      .get('customFormFieldId')
      ?.setValue(rowData.customFormFieldId);

    rowData.customFormFieldItems.forEach((item, index) => {
      const type = item?.type || 'text';
      const label = item?.label || '';
      const options = (item?.option || '').split(',').map((opt) => opt.trim());
      const data = item?.data?.trim() || '';
      const customFormFieldItemId = item?.customFormFieldItemId || '';

      const controlName = `customField${index + 1}`;

      const newField: ItemModel = {
        customFormFieldItemId,
        type,
        label,
        controlName,
        options: type === 'dropdown' || type === 'choice' ? options : [],
        data,
        index,
      };

      this.formFields.push(newField);
      console.log(this.formFields);
      this.customFields.push(
        this.formBuilder.control(data, Validators.required)
      );
    });

    this.offcanvasService.open(content, { position: 'end' });
  }

  openFormCreationModal() {
    this.resetAllForms();
    this.offcanvasService.open(this.content, { position: 'end' });
  }

  resetAllForms() {
    this.formFields = [];

    while (this.customFields.length !== 0) {
      this.customFields.removeAt(0);
    }

    this.customForm.reset();
    this.formNameForm.reset();
    this.customFieldForm.reset();
  }

  closeEnd() {
    this.resetAllForms();
    this.offcanvasService.dismiss('Cross click');
  }

  onFieldDrop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.formFields, event.previousIndex, event.currentIndex);
    moveItemInArray(
      this.customFields.controls,
      event.previousIndex,
      event.currentIndex
    );

    this.formFields.forEach((field, index) => {
      field.index = index;
    });
          
    this.showItemSuccessMessage = true;

    setTimeout(() => {
      this.showItemSuccessMessage = false;
    }, 2000);

    this.onSubmit();
  }
}
