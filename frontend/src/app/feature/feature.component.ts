import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-feature',
  templateUrl: './feature.component.html',
  styleUrls: ['./feature.component.css']
})

export class FeatureComponent {
  @Input() item: {title:string, description:string} = {title:'', description:""};

}
