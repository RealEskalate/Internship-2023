import 'dart:async';
import 'package:dio/dio.dart';

import '../models/issue_model.dart';

class IssueRemoteDataSource {
  final Dio dio;
  String Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6eyJfaWQiOiI2NDQxMGNjNTViMDcwZmYxM2RmOTI2NjkiLCJlbWFpbCI6Impob25AZ21haWwuY29tIiwidXNlck5hbWUiOiJKaG9uIiwibmFtZSI6Ikpob24gVGhvbXNvbiIsInBhc3N3b3JkIjoiJDJiJDEwJEkzazIwSm11QXBPdFpkYUpZTjBtenV5MHR3NTN4WHFhRFJtTnJOSTdEdHdPZXltRHpIb2cuIiwiYmlvIjoiQ2xldmVyIG9uZSEiLCJkZXBhcnRtZW50IjoiWW91ciBkZXBhcnRtZW50IGdvZXMgaGVyZS4iLCJ5ZWFyIjoiWW91ciB5ZWFyIGdvZXMgaGVyZS4iLCJjb3VudHJ5IjoiTmlnZXJpYSIsImF2YXRhciI6IjY0NDEwY2M0NWIwNzBmZjEzZGY5MjY2NSIsImZhdm9yaXRlVGFncyI6WyJDb2RlIiwiU3BvcnQiXSwicmVzZXRUb2tlbiI6IiIsImNyZWF0ZWRBdCI6IjIwMjMtMDQtMjBUMDk6NTg6MjkuMTM3WiIsInVwZGF0ZWRBdCI6IjIwMjMtMDQtMjBUMDk6NTg6MjkuMTM3WiIsIl9fdiI6MH0sImlhdCI6MTY4NTk0NTUzOSwiZXhwIjoxNjg4NTM3NTM5fQ.gwzN22782QZpuxxFjqHV5IYdRn2gmCTTbRj4EsSC-Cs";
  IssueRemoteDataSource({required this.dio});

  Future<Issue> getIssue() async {
    final response = await dio.get('https://school-hive-net.onrender.com/api/v1/issues',
        options: Options(headers: {'Authorization': 'Bearer $Token'}));

    if (response.statusCode == 200) {
      return Issue.fromJson(response.data);
    } else {
      throw Exception('Failed to get issue');
    }
  }
}