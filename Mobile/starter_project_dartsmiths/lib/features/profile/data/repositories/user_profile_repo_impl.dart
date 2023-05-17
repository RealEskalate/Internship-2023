import 'package:dartz/dartz.dart';

import '../../../../core/error/profile_failures.dart';
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
    } on ServerFailure {
      return Left(ServerFailure());
    }
    //   if (await networkInfo.isNetworkAvailable()) {
    //     final userProfile = await remoteDataSource.getUserProfile(id);
    //     return Right(userProfile);
    //   } else {
    //     return Left(ServerFailure());
    //   }
    // }
  }
}
