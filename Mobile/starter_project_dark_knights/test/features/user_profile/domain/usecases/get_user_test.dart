import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

class MockUserEntityRepository  extends Mock 
implements UserRepository{

}

void main(){
  GetUser usecase;
  MockUserEntityRepository mockUserEntityRepository;
  setUp(() {
mockUserEntityRepository = MockUserEntityRepository();
usecase = GetUser(mockUserEntityRepository);

  });
}