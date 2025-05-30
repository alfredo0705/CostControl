import { ExpenseDetailCreate } from "./expense-detail-create";

export interface ExpenseCreate{
  date: Date;
  monetaryFundId: number;
  storeName: string;
  documentType: string;
  notes: string;
  details: ExpenseDetailCreate[];
}