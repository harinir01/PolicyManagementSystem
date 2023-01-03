import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Policy } from 'src/app/Models/policy';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class PolicyserviceService {

  // baseurl = 'https://localhost:7024/'
  constructor(private http: HttpClient) { }


  filterValue: string = ''
  assignFilterValue(FValue: string) {
    this.filterValue = FValue;
  }
  getFilterValue(){
    return this.filterValue;
  }
  
  createPolicy(policyData: any) {
    console.warn(policyData);
    return this.http.post<Policy>('https://localhost:7024/Policy/CreatePolicy', policyData);
  }
  getPolicyByFilters(filter: string) {
    return this.http.get<any>(`https://localhost:7024/Policy/GetAllPolicies?${filter}`);
  }
  getPolicyById(policyId: number) {
    return this.http.get<any>(`https://localhost:7024/Policy/GetPolicyById?PolicyId=${policyId}`);
  }
  deletePolicy(policyId: number) {
    console.warn(policyId);
    return this.http.delete<any>(`https://localhost:7024/Policy/DeletePolicy?PolicyId=${policyId}`)
  }
  updatePolicy(policy: any) {
    console.log(policy);
    return this.http.put<any>(`https://localhost:7024/Policy/UpdatePolicy`, policy);
  }
}
