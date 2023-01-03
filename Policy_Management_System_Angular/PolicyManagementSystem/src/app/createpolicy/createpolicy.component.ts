import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PolicyserviceService } from 'src/app/service/policyservice.service';
import { Toaster } from 'ngx-toast-notifications';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { SearchpolicyComponent } from '../searchpolicy/searchpolicy.component';
import { Policy } from 'src/app/Models/policy';

@Component({
  selector: 'app-createpolicy',
  templateUrl: './createpolicy.component.html',
  styleUrls: ['./createpolicy.component.css']
})
export class CreatepolicyComponent implements OnInit {
  error: string = ""
  typeOfFunction:string="create";
  constructor(private service: PolicyserviceService, private http: HttpClient, private route: ActivatedRoute, private toaster: Toaster, private location: Location, private SearchService: SearchpolicyComponent) {

  }
  ngOnInit(): void {
  }

  createPolicy(policy : Policy) {
    this.service.createPolicy(policy).subscribe(
      {
        next: (data) => { },
        error: (error) => {
          this.error = error.error;
          console.log(this.error);
        },
        complete: () => {
          this.toaster.open({ text: 'Policy has been created successfully', position: 'top-center', type: 'success' })
          // this.location.back();
        }
      });
  }

  // Back() {
  //   this.location.back();
  // }

}



