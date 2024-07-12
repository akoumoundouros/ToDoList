import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TodoList } from '../models/to-do-list.model';
import { TodoItem } from '../models/to-do-list-item.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = '/api';

  constructor(private http: HttpClient) { }

  // Todo Lists
  getTodoLists(): Observable<TodoList[]> {
    return this.http.get<TodoList[]>(`${this.apiUrl}/ToDoList`);
  }

  createTodoList(todoList: TodoList): Observable<TodoList> {
    return this.http.post<TodoList>(`${this.apiUrl}/ToDoList`, todoList);
  }

  deleteTodoList(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/ToDoList/${id}`);
  }

  // Todo Items
  getTodoItems(listId: string): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(`${this.apiUrl}/ToDoItem/${listId}`);
  }

  createTodoItem(item: TodoItem): Observable<TodoItem> {
    return this.http.post<TodoItem>(`${this.apiUrl}/ToDoItem/`, item);
  }

  deleteTodoItem(itemId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/ToDoItem/${itemId}`);
  }
}
