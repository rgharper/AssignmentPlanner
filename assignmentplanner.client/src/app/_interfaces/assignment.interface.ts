export interface Assignment {
  id: Number;
  title: string;
  description?: string;
  dueDate: Date;
  classId: Number;
  completed: boolean;
}
