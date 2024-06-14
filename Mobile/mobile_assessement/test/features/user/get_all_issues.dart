import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/issues/data/model/info.dart';
import 'package:mobile_assessement/features/issues/domain/entities/info_detail.dart';
import 'package:mobile_assessement/features/issues/domain/repository/info_detail.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/issues/domain/usecases/getallinfo.dart';

import 'get_all_issues.mocks.dart';
// import 'package:dark_knights/features/user_profile/domain/usecases/get_number_of_followers.dart';


// import 'create_user_test.mocks.dart';
@GenerateMocks([InfoRepository])
void main() {
  late GetAllInfoDetail usecase;
  late MockInfoRepository mockUserRepository;

  setUp(() {
    mockUserRepository = MockInfoRepository();
    usecase = GetAllInfoDetail(mockUserRepository);
  });

  final tUser1 = InfoDetail(
     id : "1",
     userId :[User(id:"2", email:"ekd",
  String userName;
  String name;
  String password;
  String bio;
  String country;
  String avatar;
  List<String> favoriteTags;
  String resetToken;)],
     classId:"we",
     title : "jhs",
     description:"kfnk",
     archives:[
      Archive(id: 1, title: 'archive1'),
    Archive(id: 2, title: 'archive2')
    ],
     tags: ["db","dbjcnv"],
    // DateTime createdAt;
    // DateTime updatedAt;
    isFavorite:false,
     );

 final tUser2 = InfoDetail(
     id : "21",
     userId :"ndbb",
     classId:"asd",
     title : "aqw",
     description:"scaa",
     archives:["jhsj", "anbsj"],
     tags: ["mndkn","asndk"],
    // DateTime createdAt;
    // DateTime updatedAt;
    isFavorite:true,
     );

  List<InfoDetail> tUsers = [tUser1, tUser2];

  test("Should return all users", () async {
    when(mockUserRepository.getAllInfo())
        .thenAnswer((_) async => Right(tUsers));
    final result = await usecase(NoParams());

    expect(result, Right(tUsers));
    verify(mockUserRepository.getAllInfo());
    verifyNoMoreInteractions(mockUserRepository);
  });

  test("Should return server failure when failed to get all users.", () async {
    when(mockUserRepository.getAllInfo())
        .thenAnswer((_) async => Left(ServerFailure()));

    final result = await usecase();
    expect(result, Left(ServerFailure()));
    verify(mockUserRepository.getAllInfo());
    verifyNoMoreInteractions(mockUserRepository);
  });
}