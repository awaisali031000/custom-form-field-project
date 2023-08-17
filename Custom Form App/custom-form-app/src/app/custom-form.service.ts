import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormField } from '../app/models/custom-form-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomFormService {
  url: string = "https://localhost:7232/api/CustomFormFields/";

  constructor(private http: HttpClient) { }


  getAll(): Observable<FormField[]> {
    return this.http.get<FormField[]>(this.url);
  }

  addFormField(formData: FormField): Observable<FormField> {
    console.log(formData);
    return this.http.post<FormField>(this.url, formData);
  }
}