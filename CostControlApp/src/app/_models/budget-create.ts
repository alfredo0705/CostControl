export interface BudgetCreate{
    id: number;
    expenseTypeId: number;
    period: Date;
    amount: number;
}