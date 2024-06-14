import 'dart:convert';

import 'package:flutter_application_1/feature/issue/data/model/issue_model.dart';

import '../../../../core/errors/exception.dart';

import 'package:http/http.dart' as http;

abstract class RemoteDataSource {
  Future<List<IssueModel>> getIssue();
  Future<IssueModel> getIssueById(String id);
}

class RemoteDataSourceImpl implements RemoteDataSource {
  final http.Client client;
   String authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6eyJfaWQiOiI2NDQxMGNjNTViMDcwZmYxM2RmOTI2NjkiLCJlbWFpbCI6Impob25AZ21haWwuY29tIiwidXNlck5hbWUiOiJKaG9uIiwibmFtZSI6Ikpob24gVGhvbXNvbiIsInBhc3N3b3JkIjoiJDJiJDEwJEkzazIwSm11QXBPdFpkYUpZTjBtenV5MHR3NTN4WHFhRFJtTnJOSTdEdHdPZXltRHpIb2cuIiwiYmlvIjoiQ2xldmVyIG9uZSEiLCJkZXBhcnRtZW50IjoiWW91ciBkZXBhcnRtZW50IGdvZXMgaGVyZS4iLCJ5ZWFyIjoiWW91ciB5ZWFyIGdvZXMgaGVyZS4iLCJjb3VudHJ5IjoiTmlnZXJpYSIsImF2YXRhciI6IjY0NDEwY2M0NWIwNzBmZjEzZGY5MjY2NSIsImZhdm9yaXRlVGFncyI6WyJDb2RlIiwiU3BvcnQiXSwicmVzZXRUb2tlbiI6IiIsImNyZWF0ZWRBdCI6IjIwMjMtMDQtMjBUMDk6NTg6MjkuMTM3WiIsInVwZGF0ZWRBdCI6IjIwMjMtMDQtMjBUMDk6NTg6MjkuMTM3WiIsIl9fdiI6MH0sImlhdCI6MTY4NTk0NTUzOSwiZXhwIjoxNjg4NTM3NTM5fQ.gwzN22782QZpuxxFjqHV5IYdRn2gmCTTbRj4EsSC-Cs"; // Add an authentication token field to the class

  RemoteDataSourceImpl({required this.client, required this.authToken});

  @override
  Future<List<IssueModel>> getIssues() async {
    final url =
               'https://school-hive-net.onrender.com/api/v1'; // Replace with your API endpoint

    try {
      final response = await client.get(
        Uri.parse(url),
        headers: {'Authorization': 'Bearer $authToken'}, // Add the Authorization header to the request
      );

      if (response.statusCode == 200) {
        final List<dynamic> jsonList = json.decode(response.body);
        return jsonList.map((json) => IssueModel.fromJson(json)).toList();
      } else {
        throw ServerException(""); // Or handle specific error based on response status code
      }
    } catch (e) {
      throw ServerException(""); // Or handle specific error based on the exception
    }
  }

  @override
  Future<IssueModel> getIssueById(String id) async {
    final url =
        'https://school-hive-net.onrender.com/api/v1'; // Replace with your API endpoint for getting an issue by ID

    try {
      final response = await client.get(
        Uri.parse(url),
        headers: {'Authorization': 'Bearer $authToken'}, // Add the Authorization header to the request
      );

      if (response.statusCode == 200) {
        final dynamic jsonData = json.decode(response.body);
        return IssueModel.fromJson(jsonData);
      } else {
        throw ServerException(""); // Or handle specific error based on response status code
      }
    } catch (e) {
      throw ServerException(""); // Or handle specific error based on the exception
    }
  }

  @override
  Future<List<IssueModel>> getIssue() {
    // TODO: implement getIssue
    throw UnimplementedError();
  }
}