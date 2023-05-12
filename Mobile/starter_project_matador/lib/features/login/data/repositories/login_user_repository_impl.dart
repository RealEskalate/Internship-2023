import 'package:dartz/dartz.dart';
import 'package:matador/features/login/Domain/entities/user.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/login/Domain/repositories/user_repository.dart';
import 'package:matador/features/login/data/datasources/login_local_datasource.dart';
import 'package:matador/features/login/data/datasources/login_remote_datasource.dart';

import '../../../../core/error/exception.dart';
import '../network_info.dart';

class LoginUserRepositoryImpl implements UserRepository {
  final LoginUserLocalDataSource localDataSource;
  final LoginUserRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  LoginUserRepositoryImpl(
      {required this.localDataSource,
      required this.remoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, User>> authenticate(
      String email, String password) async {
    try {
      return Right(await remoteDataSource
          .authenticate(User(email: email, password: password)));
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
