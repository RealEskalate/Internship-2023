import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../bloc/article_bloc.dart';
import '../widgets/add_article_content.dart';
import '../widgets/add_tags.dart';
import '../widgets/publish_button.dart';
import '../widgets/text_fields.dart';
import '../widgets/title_bar.dart';

class WriteArticle extends StatefulWidget {
  const WriteArticle({super.key});

  @override
  State<WriteArticle> createState() => _WriteArticleState();
}

class _WriteArticleState extends State<WriteArticle> {
  late ArticleBloc _article_bloc;
  final _titleController = TextEditingController();
  final _subTitleController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _article_bloc = BlocProvider.of<ArticleBloc>(context);
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'write Article',
      home: Scaffold(
        body: SafeArea(
          child: ListView(
            shrinkWrap: true,
            children: [
              TitleBar(),
              AddTitleAndSubtitle(
                titleController: _titleController,
                subTitleController: _subTitleController,
              ),
              TagSelector(),
              const AddArticleContent(),
              const PublishButton(),
            ],
          ),
        ),
      ),
    );
  }
}
