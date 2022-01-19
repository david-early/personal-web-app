import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { SidebarComponent } from './sidebar.component';
import { MockProvider, MockRender } from 'ng-mocks';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { UserInfo } from 'src/app/models/userInfo';

describe('SidebarComponent', () => {
  let component: SidebarComponent;
  let userInfo = new UserInfo();
  userInfo.identityProvider = "Github"

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidebarComponent ],
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        MockProvider(AuthenticationService, {
          getUserInfo: async () => userInfo,
        }),
      ]
    })
    .compileComponents();
  });

  it('should create and assign userInfo', async() => {

    const fixture = MockRender(SidebarComponent);
    component = fixture.componentInstance;
    expect(fixture.point.componentInstance).toEqual(jasmine.any(SidebarComponent));

    await component.ngOnInit();
    expect(fixture.point.componentInstance.userInfo).toEqual(userInfo);

  });
});
