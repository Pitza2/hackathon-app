import 'package:hive/hive.dart';
part 'IssueData.g.dart';
@HiveType(typeId: 0)
class IssueData extends HiveObject{
  @HiveField(0)
  String issueTitle='';
  @HiveField(1)
  String issueText='';
  @HiveField(2)
  String specialization='';
  IssueData(String issueTitle,String issueText,String specialization){
    this.issueTitle=issueTitle;
    this.issueText=issueText;
    this.specialization=specialization;
  }
}