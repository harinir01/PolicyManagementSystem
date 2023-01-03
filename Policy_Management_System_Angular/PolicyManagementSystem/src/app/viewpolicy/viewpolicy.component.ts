import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PolicyserviceService } from 'src/app/service/policyservice.service';
import { SearchpolicyComponent } from '../searchpolicy/searchpolicy.component';
@Component({
  selector: 'app-viewpolicy',
  templateUrl: './viewpolicy.component.html',
  styleUrls: ['./viewpolicy.component.css']
})
export class ViewpolicyComponent implements OnInit{

  @Input()
  public filterDetails: any=[];
  totalLength:any;
  policyId!: number;
  policyDetails: any;
  error: string = "";
  response: string = '';
  page:number=1;
  constructor(private service: PolicyserviceService, private http: HttpClient,private SearchService: SearchpolicyComponent, private route: Router) {

  }

  ngOnInit(): void {
    console.log(this.filterDetails)
  }

  data: any = [{
    PolicyId: 0,
    Title: "",
    Description: "",
    StartDate: "",
    EndDate: "",
    InsuredAmount: 0,
    Premium:0,
    InsuredName: "",
    InsuredHolderAge: 0,
    PolicyType: 0,
    CoverageType: 0,
    VehicleNumber: "",
    VehicleModel: "",
    HouseAddress: "",
    AssetValue: 0
  }]

  EditPolicy(id: number) {

    console.warn(id);
    //Do Something
  }
  getPolicyById(policyId: number) {
    this.service.getPolicyById(this.policyId).subscribe({
      next: (data: any) => {
        this.policyDetails = data;
      }
    });
  }

  deletePolicy(policyId: number) {
    console.warn(policyId);
    this.service.deletePolicy(policyId).subscribe(
      {
        next: (data) => { this.response = data.message },
        error: (error) => this.error = error.error,
        complete:()=> this.SearchService.getPolicyByFilter()
      },
    );
  }
}
