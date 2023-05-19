import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/user_profile.dart';
import '../repositories/user_profile_repository.dart';

class GetUserProfile implements UseCase<UserProfile, String> {
  final UserProfileRepository repository;

  GetUserProfile(this.repository);
  @override
  Future<Either<Failure, UserProfile>> call(String id) async {
    return await repository.getUserProfile(id);
  }
}
