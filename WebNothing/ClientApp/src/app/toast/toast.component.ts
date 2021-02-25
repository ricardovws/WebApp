 import { Component, TemplateRef} from '@angular/core';
import { ToastService } from '../_data-services/toast.data-service';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css'],
  host: { '[class.ngb-toasts]': 'true' },
})
export class ToastComponent{

  constructor(public toastService: ToastService) { }

}
