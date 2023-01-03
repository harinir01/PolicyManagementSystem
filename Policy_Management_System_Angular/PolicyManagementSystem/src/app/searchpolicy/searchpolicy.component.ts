import { Component } from '@angular/core';
import { PolicyserviceService } from 'src/app/service/policyservice.service';
import { query } from './type';

@Component({
  selector: 'app-searchpolicy',
  templateUrl: './searchpolicy.component.html',
  styleUrls: ['./searchpolicy.component.css']
})
export class SearchpolicyComponent {


  filterValue: any = [];
  filterType: string = '';
  searchValue: string = '';
  searchType: string = '';
  policyType: number = 0;
  startDate!: Date;
  endDate!: Date;
  premium: number = 0;
  
  // pageNumber: number = 0;
  // pageSize: number = 0;
  queryparams: query[] = [];

  constructor(private service: PolicyserviceService) {
  }
  ngOnInit(): void {
    this.getPolicyByFilter();
  }
  getPolicyByFilters(filter: any, filterType: string) {
    let q = "";
    let a: query = {
      fType: filterType,
      fValue: filter
    };
    this.queryparams.forEach(element => {
      if (element.fType == filterType) {
        let index = this.queryparams.indexOf(element);
        this.queryparams.splice(index, 1);
      }
    });
    this.queryparams.push(a);
    this.queryparams.forEach(element => {
      q += `${element.fType}=${element.fValue}&`
    });
    this.service.assignFilterValue(q);
    this.getPolicyByFilter();
  }
  getPolicyByFilter() {
    let querystring = "";
    this.queryparams.forEach(element => {
      querystring += `${element.fType}=${element.fValue}&`
    });
    querystring = this.service.getFilterValue();
    this.service.getPolicyByFilters(querystring).subscribe((data: any) => {
      console.log(data);
      this.filterValue = data;
    });
  }

}
