import 'dart:async';
import 'package:shared_preferences/shared_preferences.dart';

import '../models/issue_model.dart';

class IssueLocalDataSource {
  final SharedPreferences prefs;

  IssueLocalDataSource({required this.prefs});

  Future<void> saveIssue(Issue issue) async {
    await prefs.setString('issue', issue.toJson() as String);
  }

  Future<Issue?> getIssue() async {
    final issueJson = prefs.getString('issue');

    if (issueJson != null) {
      return Issue.fromJson(issueJson as Map<String, dynamic>);
    } else {
      return null;
    }
  }
}