export class ItemModel {
  customFormFieldItemId?: string;
  type!: 'text' | 'date' | 'dropdown' | 'choice';
  label!: string;
  controlName!: string;
  options?: string[];
  option?: string;
  data?: string;
  index!: number;
  [key: string]: any;
}