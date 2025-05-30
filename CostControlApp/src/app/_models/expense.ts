export interface Expense {
  id: number;
  userId: number;
  date: Date;
  monetaryFundId: number;
  storeName: string;
  documentType: string;
  notes: string;
}