import 'package:dartz/dartz.dart';

import '../../../../core/error/profile_failures.dart';
import '../../domain/entities/user_profile.dart';
import '../../domain/repositories/user_profile_repository.dart';

class UserProfleRepositoryImpl implements UserProfileRepository {
  @override
  Future<Either<Failure, UserProfile>> getUserProfile(String id) {
    // TODO: implement getUserProfile
    throw UnimplementedError();
  }
}
