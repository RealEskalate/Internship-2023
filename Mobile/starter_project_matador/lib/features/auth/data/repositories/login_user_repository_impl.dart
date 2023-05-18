import 'package:dartz/dartz.dart';
import 'package:matador/features/auth/data/datasources/login_remote_datasource.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/auth/data/models/login_model.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:matador/features/auth/domain/repositories/login_repository.dart';

import '../../../../core/error/exception.dart';

class LoginUserRepositoryImpl implements LoginUserRepository {
  final LoginUserRemoteDataSource remoteDataSource;

  LoginUserRepositoryImpl({
    required this.remoteDataSource,
  });

  @override
  Future<Either<Failure, AuthUser>> authenticate(
      String email, String password) async {
    try {
      return Right(await remoteDataSource
          .authenticate(LoginModel(email: email, password: password)));
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
