import 'dart:convert';
import 'package:flutter_application_1/feature/issue/data/model/issue_model.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../../../../core/errors/exception.dart';

abstract class Cache {
  Future<void> cacheIssues(List<IssueModel> issues);
  Future<List<IssueModel>> getCachedIssues();
  Future<void> cacheIssue(IssueModel issue);
  Future<IssueModel> getCachedIssueById(String id);
}

class LocalDataSource implements Cache {
  final SharedPreferences sharedPreferences;

  LocalDataSource({required this.sharedPreferences});

  @override
  Future<void> cacheIssues(List<IssueModel> issues) async {
    final encodedIssues =
        issues.map((issue) => json.encode(issue.toJson())).toList();
    await sharedPreferences.setStringList('cached_issues', encodedIssues);
  }

  @override
  Future<List<IssueModel>> getCachedIssues() async {
    final cachedIssues = sharedPreferences.getStringList('cached_issues');
    if (cachedIssues != null) {
      return cachedIssues
          .map((encodedIssue) => IssueModel.fromJson(json.decode(encodedIssue)))
          .toList();
    } else {
      throw CacheException(
          ""); // Or handle specific error when no cached data is available
    }
  }

  @override
  Future<void> cacheIssue(IssueModel issue) async {
    final encodedIssue = json.encode(issue.toJson());
    await sharedPreferences.setString('cached_issue_${issue.id}', encodedIssue);
  }

  @override
  Future<IssueModel> getCachedIssueById(String id) async {
    final cachedIssue = sharedPreferences.getString('cached_issue_$id');
    if (cachedIssue != null) {
      return IssueModel.fromJson(json.decode(cachedIssue));
    } else {
      throw CacheException(
          ""); // Or handle specific error when the cached issue is not found
    }
  }
}
