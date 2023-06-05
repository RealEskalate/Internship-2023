import 'dart:async';

import 'package:mobile_assessement/features/issue/data/models/issue_model.dart';

import '../data_sources/issue_local_data_source.dart';
import '../data_sources/issue_remote_data_source.dart';

import '../../domain/repositories/issue_repository.dart';

class IssueRepositoryImpl implements IssueRepository {
  final IssueRemoteDataSource remoteDataSource;
  final IssueLocalDataSource localDataSource;

  IssueRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
  });

  @override
  Future<Issue> getIssue() async {
    Future<Issue> issue = (await localDataSource.getIssue()) as Future<Issue>;

    // ignore: unnecessary_null_comparison
    if (issue != null) {
      return issue;
    } else {
      Future<Issue> remoteIssue = (await remoteDataSource.getIssue()) as Future<Issue>;
      await localDataSource.saveIssue(remoteIssue as Issue);

      return remoteIssue;
    }
  }
}