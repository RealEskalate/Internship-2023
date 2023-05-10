import 'package:dartz/dartz.dart';

import '../../../../core/error/profile_failures.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/user_profile.dart';
import '../repositories/user_profile_repository.dart';

class GetUserProfile implements Usecase<UserProfile, String> {
  final UserProfileRepository repository;

  GetUserProfile(this.repository);
  @override
  Future<Either<Failure, UserProfile>> call(String id) async {
    return await repository.getUserProfile(id);
  }
}
