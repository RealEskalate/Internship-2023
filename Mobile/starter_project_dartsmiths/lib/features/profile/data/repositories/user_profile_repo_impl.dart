import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/network_info.dart';
import '../../domain/entities/user_profile.dart';
import '../../domain/repositories/user_profile_repository.dart';
import '../datasources/user_profile_remote_data_source.dart';

class UserProfleRepositoryImpl implements UserProfileRepository {
  final UserProfileRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  UserProfleRepositoryImpl(this.remoteDataSource, this.networkInfo);

  @override
  Future<Either<Failure, UserProfile>> getUserProfile(String id) async {
    if (await networkInfo.isNetworkAvailable()) {
      final userProfile = await remoteDataSource.getUserProfile(id);
      return Right(userProfile);
    } else {
      return Left(ServerFailure());
    }
  }
}
