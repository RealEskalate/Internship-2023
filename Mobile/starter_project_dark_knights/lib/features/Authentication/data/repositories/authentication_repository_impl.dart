import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dartz/dartz.dart';
import 'package:http/http.dart';

import '../../../../core/errors/exception.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/repositories/authentication_repository.dart';
import '../datasources/authenication_remote_data_sources.dart';
import '../datasources/authentication_local_data_source.dart';


class AuthenticationRepositoryImpl implements AuthenticationRepository {
  final AuthenticationRemoteDataSource remoteDataSource;
  final AuthenticationLocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  AuthenticationRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, Authentication>> login(Authentication user) async {
    try {
      final response = await remoteDataSource.login(user);
      return Right(response);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }

  @override
  Future<Either<Failure, Authentication>> signup(Authentication newuser) async {
    // TODO: implement signup
    try {
      final response = await remoteDataSource.signup(newuser);
      return Right(response);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }
}
