export interface IApiResponse<T> {
    data: T;
    message: string;
    success: Status;
  }

export enum Status {
    Error,
    Success
  }