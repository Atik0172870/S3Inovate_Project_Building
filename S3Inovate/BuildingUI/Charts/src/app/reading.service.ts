import { HttpClient, ɵangular_packages_common_http_http_a } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ReadingService {

  constructor(private _http : HttpClient) { }

getReadingData(buildingId : Number,objectId : number,datafieldId : number,fromDate: string,toDate:string) : Observable<any>
{
  return this._http.get(`https://localhost:44375/api/reading/atik/${buildingId}/${objectId}/${datafieldId}/${fromDate}/${toDate}`);
}
  
  
}
