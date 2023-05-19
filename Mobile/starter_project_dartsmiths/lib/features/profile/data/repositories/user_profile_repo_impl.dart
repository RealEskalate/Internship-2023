import 'package:dartsmiths/core/error/exceptions.dart';
import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartz/dartz.dart';
import '../../domain/entities/user_profile.dart';
import '../../domain/repositories/user_profile_repository.dart';
import '../datasources/user_profile_remote_data_source.dart';

class UserProfleRepositoryImpl implements UserProfileRepository {
  final UserProfileRemoteDataSource remoteDataSource;

  UserProfleRepositoryImpl(
    this.remoteDataSource,
  );

  @override
  Future<Either<Failure, UserProfile>> getUserProfile(String id) async {
    try {
      final userProfile = await remoteDataSource.getUserProfile(id);
      return Right(userProfile);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
