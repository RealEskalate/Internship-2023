import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';
import 'package:flutter_application_1/core/errors/failures.dart';
import '../../../../core/errors/exception.dart';
import '../../../../core/network/network_info.dart';
import '../../../../feature/issue/domain/entities/Issue_entity.dart';
import '../../../../feature/issue/domain/repositort/issue_repository.dart';
import '../../../../feature/issue/data/dataSources/localdatasource.dart';
import '../../../../feature/issue/data/dataSources/remotedatasource.dart';

class IssueRepositoryImpl implements IssueRepository {
  final RemoteDataSource remoteDataSource;
  final LocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  IssueRepositoryImpl({
    required this.localDataSource,
    required this.remoteDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, List<Issue>>> getIssue() async {
    if (await networkInfo.isConnected) {
      try {
        final remoteIssues = await remoteDataSource.getIssue();
        localDataSource.cacheIssues(remoteIssues);
        return Right(remoteIssues.cast<Issue>());
      } on ServerException {
        return Left(ServerFailure("Internal Server Failure!"));
      }
    } else {
      try {
        final localIssues = await localDataSource.getCachedIssues();
        return Right(localIssues.cast<Issue>());
      } on CacheException {
        return Left(CacheFailure("Local Cache Server Failure"));
      }
    }
  }

  @override
  Future<Either<Failure, Issue>> getIssueById(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final remoteIssue = await remoteDataSource.getIssueById(id);
        localDataSource.cacheIssue(remoteIssue);
        return Right(remoteIssue as Issue);
      } on ServerException {
        return Left(ServerFailure("Internal Server Failure!"));
      }
    } else {
      try {
        final localIssue = await localDataSource.getCachedIssueById(id);
        return Right(localIssue as Issue);
      } on CacheException {
        return Left(CacheFailure("Local Cache Server Failure"));
      }
    }
  }

}