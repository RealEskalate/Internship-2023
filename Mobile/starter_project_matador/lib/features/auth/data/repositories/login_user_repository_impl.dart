import 'package:dartz/dartz.dart';
import 'package:matador/features/auth/data/datasources/login_remote_datasource.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:matador/features/auth/domain/repositories/login_repository.dart';

import '../../../../core/error/exception.dart';

class LoginUserRepositoryImpl implements LoginUserRepository {
  final LoginRemoteDataSource remoteDataSource;

  LoginUserRepositoryImpl({
    required this.remoteDataSource,
  });

  @override
  Future<Either<Failure, String>> authenticate(AuthUser user) async {
    try {
      final loginModel =
          await remoteDataSource.authenticate(user.email, user.password);
      return Right(loginModel.id);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
