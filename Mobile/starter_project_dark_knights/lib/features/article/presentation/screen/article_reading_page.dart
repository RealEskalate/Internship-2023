import 'package:flutter/material.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../bloc/article_bloc.dart';
import '../widgets/article_like_button.dart';
import '../widgets/article_post.dart';
import '../widgets/header.dart';
import '../widgets/header_icons.dart';
import '../../../user_profile/presentation/bloc/user_profile_bloc.dart';

class ArticleReadingPage extends StatefulWidget {
  final article_id;
  const ArticleReadingPage({super.key, required this.article_id});

  @override
  State<ArticleReadingPage> createState() => _ArticleReadingPageState();
}

class _ArticleReadingPageState extends State<ArticleReadingPage> {
  late ArticleBloc _articleBloc;
  late UserProfileBloc _userProfileBloc;
  @override
  void initState() {
    super.initState();
    _articleBloc = BlocProvider.of<ArticleBloc>(context);
    _articleBloc.add(GetArticleByIdEvent(articleId: widget.article_id));
    _userProfileBloc = BlocProvider.of<UserProfileBloc>(context);
  }

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<ArticleBloc, ArticleState>(
      builder: (context, state) {
        if (state is ArticleLoadingState) {
          return const Scaffold(
              body: Center(
            child: CircularProgressIndicator(),
          ));
        } else if (state is ArticleSuccessState) {
          final article = state.article;
          _userProfileBloc.add(LoadUserEvent(userId: article.postedBy));
          return Scaffold(
              body: Column(
                children: [
                  const HeaderIconButtons(),
                  Expanded(
                    child: SingleChildScrollView(
                      child: Column(
                        children: [
                          BlocBuilder<UserProfileBloc, userProfileState>(
                              builder: ((context, state) {
                            if (state is ProfileLoading) {
                              return const Center(
                                  child: CircularProgressIndicator());
                            } else if (state is ProfileLoaded) {
                              final user = state.user;
                              return Header(
                                userInfo: user,
                              );
                            }
                            return const Text('Error');
                          })),
                          ArticlePost(
                            description: article.description,
                            imageUrl: article.imageUrl,
                          )
                        ],
                      ),
                    ),
                  ),
                ],
              ),
              floatingActionButton:
                  ArticleLikeButton(likeCount: article.likeCount));
        }
        return const Text('Try Again and again');
      },
    );
  }
}
