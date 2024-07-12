import { TodoItem } from './to-do-list-item.model'
export interface TodoList {
  id: string;
  name: string;
  items?: TodoItem[];
}
