import { ItemModel } from '../models/custom-form-item-model';

export class FormField {
  customFormFieldId?: string;
  formName!: string;
  customFormFieldItems!: ItemModel[];
}