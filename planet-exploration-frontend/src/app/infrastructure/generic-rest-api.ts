import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

export class GenericRestApi<T> {
    protected url = '';
    constructor(protected http: HttpClient, private controller: string = '') {
        this.url = `/${this.controller}`;
    }
  
    public getAll(): Observable<T[]> {
      return this.http.get<T[]>(this.url);
    }
    
  
    public getById(id: number): Observable<T> {
      return this.http.get<T>(`${this.url}/${id}`);
    }
  
    public add(data: T): Observable<T> {
      return this.http.post<T>(this.url, data);
    }
  
    public update(data: T): Observable<T> {
      return this.http.put<T>(this.url, data);
    }

    public deleteById(id: number): Observable<void> {
        const url = `${this.url}/${id}`;
        return this.http.delete<void>(url);
      }
}