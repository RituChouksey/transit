import { TestBed, async } from '@angular/core/testing';
import { StationsComponent } from './stations.component';
describe('StationsComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        StationsComponent
      ],
    }).compileComponents();
  }));
  it('should Let user enter start and end stations', async(() => {
    const fixture = TestBed.createComponent(StationsComponent);
    
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));
  it(`should have as title 'stations'`, async(() => {
    const fixture = TestBed.createComponent(StationsComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('app');
  }));
  it('should not allow blanks for stations', async(() => {
    const fixture = TestBed.createComponent(StationsComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Welcome to racetrack!');
  }));
});
