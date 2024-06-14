
import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures.dart';
import '../entities/Issue_entity.dart';
import '../repositort/issue_repository.dart';

class GetIssueById {
  final IssueRepository repository;
  GetIssueById({required this.repository});

  Future<Either<Failure, Issue>> call(String id) async {
    return await repository.getIssueById(id);
  }
}