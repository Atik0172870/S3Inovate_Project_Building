import { Component } from '@angular/core';
import { ReadingService } from './reading.service';
import {Chart} from 'chart.js'
import { FormControl, FormGroup } from '@angular/forms';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Charts';
chart=[];
  model ={
    buildingselectedValue:null,
    objectselectedValue:null,
    dataFieldselectedValue:null
  }


  range = new FormGroup({
    start:new FormControl(),
    end : new FormControl()

  });



  constructor(private readingservice: ReadingService){}
  ngOnInit(){
  
  }
showChart(){
  // alert(this.model.buildingselectedValue)
  // alert(this.range.value.start)
  // alert(this.range.value.end)
  var fromDate = new Date(this.range.value.start).toDateString()
  var toDate = new Date(this.range.value.end).toDateString()
  

  this.readingservice.getReadingData(this.model.buildingselectedValue
    ,this.model.objectselectedValue,this.model.dataFieldselectedValue
    ,fromDate,toDate).subscribe(data=> {


    let maxValue = data.map(res=> res.value)
    let minValue = data.map(res=> res.value)
     
    let timeStamps = [];
    data.forEach(res => {
      let jsTimeStamp = new Date(res.timeStamp)
      timeStamps.push(jsTimeStamp.toLocaleTimeString('en',{year:'numeric',month:'short',day:'numeric'}))
    });
    debugger;
    this.chart = new Chart('canvas',{
      type:'line',
      data:{
        labels:timeStamps,
       datasets:[
         {
          label: 'My First dataset',
					backgroundColor: 'red',
            data:maxValue,
            bordercolor:'blue',
            fill:false
        },
        {
          label: 'My second dataset',
					backgroundColor: 'pink',
          data:minValue,
          bordercolor:'green',
          fill:false
      }
      ]
      },
      options:{
        legend:{
          display:false
        },
        scales:{
        xAxes:[{
          display:true
        }],
        yAxes:[{
          display:true
        }]
      }
      }
    })
  });
}

}
