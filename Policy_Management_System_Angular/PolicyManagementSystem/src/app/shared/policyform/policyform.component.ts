import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Policy } from 'src/app/Models/policy';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { PolicyserviceService } from 'src/app/service/policyservice.service';
@Component({
  selector: 'app-policyform',
  templateUrl: './policyform.component.html',
  styleUrls: ['./policyform.component.css']
})
export class PolicyformComponent implements OnInit {

  endyear!: number;
  startyear!: number;
  currentDate: Date = new Date();
  // policyId: number = 0;
  policyForm!: FormGroup;
  formSubmitted: boolean = false;
  @Input() 
  type:string='';
  @Input()
  policyDetail:Policy = {
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
    
  @Input()
  policyid: number=0; //item
  @Input()
  disabledValue!:boolean;
  @Output()
  output = new EventEmitter<Policy>
  constructor(private FB: FormBuilder, private location: Location, private route: ActivatedRoute, private service: PolicyserviceService) {

  }
  ngOnInit(): void {
  }
  ngOnChanges(){
    console.warn(this.policyid);
    console.warn(this.policyDetail.policyId);
    this.LoadForm();
    if(this.type=="view")
    this.policyForm.disable();
  }
  
  LoadForm() {
    console.warn(this.policyDetail)
    this.policyForm = this.FB.group({
      Title: [this.policyDetail.title, [Validators.required, Validators.minLength(3), Validators.maxLength(10)]],
      Description: [this.policyDetail.description, [Validators.required, Validators.minLength(5), Validators.maxLength(500)]],
      StartDate: [this.policyDetail.startDate,[Validators.required]],
      EndDate: [this.policyDetail.endDate, [Validators.required]],
      InsuredAmount: [this.policyDetail.insuredAmount, [Validators.required]],
      InsuredName: [this.policyDetail.insuredName, [Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      InsuredHolderAge: [this.policyDetail.insuredHolderAge, [Validators.required]],
      PolicyType: [this.policyDetail.policyTypeId, [Validators.required]],
      VehicleModel: [this.policyDetail.vehicleModel, [Validators.required]],
      VehicleNumber: [this.policyDetail.vehicleNumber, [Validators.required]],
      HouseAddress: [this.policyDetail.houseAddress, [Validators.required]],
      AssetValue: [ this.policyDetail.assetValue,[Validators.required]],
      CoverageType: [ this.policyDetail.coverageId,[Validators.required]],
    });
    
  }
  validateEndDateOfPolicy() {
    this.endyear = parseInt(this.policyForm.value['EndDate']);
    this.startyear = parseInt(this.policyForm.value['StartDate']);
    if ((this.endyear < this.startyear)) {
      return true;
    }
    return false;
  }

  createPolicy() {
    this.formSubmitted = true;
    const policy ={
      policyId: 0,
      title: this.policyForm.value['Title'],
      description: this.policyForm.value['Description'],
      startDate: this.policyForm.value['StartDate'],
      endDate: this.policyForm.value['EndDate'],
      insuredAmount: this.policyForm.value['InsuredAmount'],
      insuredName: this.policyForm.value['InsuredName'],
      insuredHolderAge: this.policyForm.value['InsuredHolderAge'],
      policyTypeId: this.policyForm.value['PolicyType'],
      vehicleModel: this.policyForm.value['VehicleModel'],
      vehicleNumber: this.policyForm.value['VehicleNumber'],
      houseAddress: this.policyForm.value['HouseAddress'],
      assetValue: this.policyForm.value['AssetValue'],
      coverageId: this.policyForm.value['CoverageType'],
    }
    this.output.emit(policy);
  }

  updatePolicy() {
    console.warn(this.policyid);
    const policy = {
      policyId: this.policyid,
      title: this.policyForm.value['Title'],
      description: this.policyForm.value['Description'],
      startDate: this.policyForm.value['StartDate'],
      endDate: this.policyForm.value['EndDate'],
      insuredAmount: this.policyForm.value['InsuredAmount'],
      insuredName: this.policyForm.value['InsuredName'],
      insuredHolderAge: this.policyForm.value['InsuredHolderAge'],
      policyTypeId: this.policyForm.value['PolicyType'],
      vehicleDetailId: 0,
      vehicleModel: this.policyForm.value['VehicleModel'],
      vehicleNumber: this.policyForm.value['VehicleNumber'],
      houseDetailId: 0,
      houseAddress: this.policyForm.value['HouseAddress'],
      assetValue: this.policyForm.value['AssetValue'],
      coverageId: this.policyForm.value['CoverageType'],
    }
    console.warn(policy);
    this.output.emit(policy);
  }
  Back() {
    this.location.back();
  }
}
