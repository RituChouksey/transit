import { Component } from '@angular/core'
import { StationService } from './station.service'

@Component({
  selector: 'stations',
  templateUrl: './stations.component.html',
  providers: [StationService]
})

export class StationsComponent {
  constructor(private service: StationService) { }
  public stations: stationPair = { start: '59 St - Columbus Circle', end: 'Grand Central - 42 St'}
  public distance: number = 0
  public error: string = '';

    public getDistance() {
        console.log('in getDistance function')
      this.service.getDistance(this.stations.start, this.stations.end)
        .subscribe((data: number) => {
          this.distance = data;
          debugger;
        },
          error => this.onError(error));
        
  }
  public onError(error: string) {
    this.error = error;
  }

}   
interface stationPair {
    start: string, 
    end: string
}
