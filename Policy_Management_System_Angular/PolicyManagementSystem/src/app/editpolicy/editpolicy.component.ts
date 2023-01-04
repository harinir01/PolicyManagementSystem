import { Component, OnInit } from '@angular/core';
import { Toaster } from 'ngx-toast-notifications';
import { Policy } from 'src/app/Models/policy';
import { PolicyserviceService } from 'src/app/service/policyservice.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editpolicy',
  templateUrl: './editpolicy.component.html',
  styleUrls: ['./editpolicy.component.css']
})
export class EditpolicyComponent implements OnInit{

  error: string = ""
  response: string="";
  typeOfFunction:string="edit";
  policyId:number=0;
  readOnly!:boolean;
  policyData: Policy = {
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
  }
  constructor(private service: PolicyserviceService, private toaster: Toaster,private location : Location,private route: ActivatedRoute){

  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params['policyId'])
        this.policyId = params['policyId']
    });
    if(this.policyId==0){
      this.readOnly=false;
    }
    else{
      this.readOnly=true;
    }
    this.GetPolicyDetails();
    
  }
  GetPolicyDetails() {
    this.service.getPolicyById(this.policyId).subscribe({
      next: (data) => {
        this.policyData = data;
        console.log(this.policyData)
      },
    });
  }
  editPolicy(policy : Policy) {
    console.log(policy);
    this.service.updatePolicy(policy).subscribe({
      next: (data) => this.response = data,
      error: (error) => { this.error = error.error.message, console.warn(error.error.message) },
      complete: () => {
        this.toaster.open({ text: 'Policy updated successfully', position: 'top-center', type: 'success' });
        // this.Back();
      }
    });
  }
  // Back() {
  //   this.location.back();
  //   // this.router.navigate(['/searchpolicy']);
  // }

}
