import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ToastService {
  toasts: any[] = [];

  show(header: string, body: string, className: string) {
    this.toasts.push({ header, body, className });
  }

  remove(toast) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}
