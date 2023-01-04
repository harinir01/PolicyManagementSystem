import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Policy } from '../Models/policy';
import { SearchpolicyComponent } from '../searchpolicy/searchpolicy.component';
import { ActivatedRoute } from '@angular/router';
import { PolicyserviceService } from '../service/policyservice.service';

@Component({
  selector: 'app-viewpolicyinform',
  templateUrl: './viewpolicyinform.component.html',
  styleUrls: ['./viewpolicyinform.component.css']
})
export class ViewpolicyinformComponent implements OnInit{

  @Input()
  public filterDetails!: any;
  policyData:Policy = {
    policyId: 0,
    title: '',
    description: '',
    startDate: '',
    endDate: '',
    insuredAmount: 0,
    insuredName: '',
    insuredHolderAge: 0,
    policyTypeId: 0,
    vehicleModel: '',
    vehicleNumber: '',
    houseAddress: '',
    assetValue: 0,
    coverageId: 0,
  };
  policyId:number=0;
  readOnly!:boolean;
  typeOfFunction:string="view";

  constructor(private SearchService: SearchpolicyComponent,private route:ActivatedRoute,private service:PolicyserviceService){

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
        this.policyId = params['policyId']
    });
    this.GetPolicyDetails();
  }
  GetPolicyDetails() {
    this.service.getPolicyById(this.policyId).subscribe({
      next: (data) => {
        this.policyData = data;
      },
     
    });
  }


  

}
