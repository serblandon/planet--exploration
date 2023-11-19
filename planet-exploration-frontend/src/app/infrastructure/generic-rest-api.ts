import { HttpClient } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { IApiResponse } from "./api-response";

export class GenericRestApi<T> {
    protected url = '';
    constructor(protected http: HttpClient, private controller: string = '') {
        this.url = this.getUrlForModel();
    }
  
    public getAll(): Observable<T[]> {
      return this.http.get<IApiResponse<T[]>>(this.url).pipe(map(x => x.data));
    }
  
    public getById(id: number): Observable<T> {
      return this.http.get<IApiResponse<T>>(`${this.url}/${id}`).pipe(map(x => x.data));
    }
  
    public add(data: T): Observable<T> {
      return this.http.post<IApiResponse<T>>(this.url, data).pipe(map(x => x.data));
    }
  
    public update(data: T): Observable<IApiResponse<T>> {
      return this.http.put<IApiResponse<T>>(this.url, data);
    }

    public deleteById(id: number): Observable<void> {
        const url = `${this.url}/${id}`;
        return this.http.delete<void>(url);
      }

    private getUrlForModel(): string {
        return `/${this.controller}`;
      }
}