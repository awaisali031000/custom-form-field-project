import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomFormComponent } from './custom-form/custom-form.component';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { AgGridModule } from 'ag-grid-angular';
import { CdkDrag, CdkDropList, CdkDropListGroup, DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [AppComponent, CustomFormComponent],
  imports: [
    BrowserModule, 
    ReactiveFormsModule, 
    NgbModule,
    HttpClientModule, 
    AgGridModule,
    DragDropModule,
    FormsModule,
    CdkDropListGroup,
    CdkDrag,
    CdkDropList,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}