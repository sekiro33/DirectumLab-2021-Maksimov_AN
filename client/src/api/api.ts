import { UnauthorizedError } from "./unauthorized-error";

export class Api {
  private readonly baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  private getHeader() {
    return {
      'Content-Type': 'application/json',
    };
  }

  private async http<T>(url: string, method: 'POST' | 'GET', body?: any, headers?: any): Promise<T> {
    const response = await fetch(`${this.baseUrl}/${url}`, {
      method: method,
      mode: 'cors',
      credentials: "include",
      headers: {
        ...this.getHeader(),
        ...headers,
      },
      body:
        body &&
        JSON.stringify({
          ...body,
        }),
    });

    if (response.ok) {
      return await response.json();
    } else if (response.status == 401) {
      throw new UnauthorizedError();
    } else {
      throw new Error();
    }
  }

  public async post<T>(url: string, headers?: any, body?: any): Promise<T> {
    return await this.http<T>(url, 'POST', body, headers);
  }

  public async get<T>(url: string, headers?: any): Promise<T> {
    return await this.http<T>(url, 'GET', null, headers);
  }
}