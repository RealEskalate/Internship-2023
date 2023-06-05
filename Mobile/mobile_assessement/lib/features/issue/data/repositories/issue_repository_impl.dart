import 'dart:async';

import 'package:mobile_assessement/features/issue/data/models/issue_model.dart';

import '../data_sources/issue_local_data_source.dart';
import '../data_sources/issue_remote_data_source.dart';
import '../models/issue_model.dart';
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
    final issue = await localDataSource.getIssue();

    if (issue != null) {
      return issue;
    } else {
      Future<Issue> remoteIssue = (await remoteDataSource.getIssue()) as Future<Issue>;
      await localDataSource.saveIssue(remoteIssue as Issue);

      return remoteIssue;
    }
  }
}