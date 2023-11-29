import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CreateMember, Member } from 'src/app/models/member.model';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  private memberIdSource = new BehaviorSubject<string | null>(null);
  currentMemberId = this.memberIdSource.asObservable();

  private readonly httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };

  constructor(private http: HttpClient) { }

  changeMemberId(memberId: string | null) {
    this.memberIdSource.next(memberId);
  }

  getMembers(): Observable<Member[]> {
    return this.http.get<Member[]>('https://localhost:7106/api/member');
  }

  getMemberById(id: string): Observable<Member> {
    return this.http.get<Member>(`https://localhost:7106/api/member/${id}`);
  }

  getMembershipDetailsByUserId(id: any): Observable<Member> {
    return this.http.get<Member>(`https://localhost:7106/api/member/user/${id}`);
  }

  addMember(createMember: CreateMember): Observable<Member> {
    return this.http.post<Member>(`https://localhost:7106/api/member`, createMember);
  }


  editMember(Member: Member): Observable<Member> {
    return this.http.post<Member>(`https://localhost:7106/api/Member/${Member.id}`,
      {
        MemberId: Member.id,
        MemberName: Member.email,
        email: Member.email,
      });
  }

  deleteMember(id: String): Observable<any> {
    return this.http.delete<any>('https://localhost:7106/api/member/' + id,
      {
        headers: this.getHeaders()
      });

  }
  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json'
    });
  }
}
