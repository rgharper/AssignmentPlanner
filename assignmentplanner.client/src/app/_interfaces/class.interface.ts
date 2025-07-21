import { Assignment } from '../_interfaces/assignment.interface';

// AssignmentPlanner - Class Interface
export interface Class {
  id?: Number;
  name: string;
  assignments: Assignment[];
}
