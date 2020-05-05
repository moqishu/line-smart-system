DELIMITER ;

CREATE DATABASE IF NOT EXISTS natsucloud ;

USE natsucloud;

CREATE TABLE IF NOT EXISTS sys_user(
  id bigint NOT NULL DEFAULT 0 COMMENT '主键',
  username varchar(50) NOT NULL DEFAULT '' COMMENT '用户名',
  password VARCHAR(100) NOT NULL DEFAULT '' COMMENT '密码',
  lastLoginTime datetime COMMENT '上次登录时间',
  isAdmin bit NOT NULL DEFAULT 0 COMMENT '是否管理员',
  status int NOT NULL DEFAULT 0 COMMENT '账号状态 0 使用 1 注销',
  isLocked bit NOT NULL DEFAULT 0 COMMENT '账号是否锁定，1：锁定，0未锁定', 
  remark varchar(512) NOT NULL DEFAULT '' COMMENT '备注',
  createTime datetime NOT NULL COMMENT '创建时间',
  updateTime datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (id),
  UNIQUE INDEX UK_username (username)
  )
  ENGINE=INNODB
  DEFAULT CHARSET=utf8;

-- INSERT INTO sys_user (id, username, password, lastLoginTime, isAdmin, status, isLocked, remark, createTime)
-- VALUES (699908224381087744, '管理员', '12345', NOW(), 1, 0, 0, '超级管理员', NOW());

CREATE TABLE IF NOT EXISTS sys_sqldemo(
   id bigint NOT NULL DEFAULT 0 COMMENT '主键',
   inDate date not null comment '日期',
   createTime datetime NOT NULL COMMENT '创建时间',
   PRIMARY KEY (id)
    )
 ENGINE=INNODB
 DEFAULT CHARSET=utf8;


CREATE TABLE IF NOT EXISTS sys_role(
  id bigint NOT NULL DEFAULT 0 COMMENT '主键',
  name varchar(50) NOT NULL DEFAULT '' COMMENT '角色名',
  remark varchar(512) NOT NULL DEFAULT '' COMMENT '备注',
  createTime datetime NOT NULL COMMENT '创建时间',
  updateTime datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (id),
  UNIQUE INDEX UK_name (name)
  )
  COMMENT '角色表'
  ENGINE=INNODB
  DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS sys_author(
  id bigint NOT NULL DEFAULT 0 COMMENT '主键',
  roleId bigint NOT NULL DEFAULT 0 COMMENT '角色id',
  resourceId bigint NOT NULL DEFAULT 0 COMMENT '资源id',
  resourceType int NOT NULL DEFAULT 0 COMMENT ' 资源类型 0:菜单;1:按钮',
  createTime datetime NOT NULL COMMENT '创建时间',
  updateTime datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (id)
  )
  COMMENT '权限表'
  ENGINE=INNODB
  DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS sys_menu(
  id bigint NOT NULL DEFAULT 0 COMMENT '主键',
  name varchar(100) NOT NULL DEFAULT '' COMMENT '名称',
  url varchar(100) NOT NULL DEFAULT '' COMMENT '网址',
  parentId bigint NOT NULL DEFAULT 0 COMMENT '父级id',
  sort int NOT NULL DEFAULT 0 COMMENT '排序',
  level int NOT NULL DEFAULT 0 COMMENT '模块级别 1-顶级  2-二级',
  icon varchar(100) NOT NULL DEFAULT '' COMMENT '图标',
  remark varchar(512) NOT NULL DEFAULT '' COMMENT '备注',
  createTime datetime NOT NULL COMMENT '创建时间',
  updateTime datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (id),
  UNIQUE INDEX UK_name (name)
  )
  COMMENT '菜单表'
  ENGINE=INNODB
  DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS sys_button(
  id bigint NOT NULL DEFAULT 0 COMMENT '主键',
  name varchar(100) NOT NULL DEFAULT '' COMMENT '名称',
  title varchar(100) NOT NULL DEFAULT '' COMMENT '标题',
  code varchar(100) NOT NULL DEFAULT '' COMMENT '编码',
  muneId bigint NOT NULL DEFAULT 0 COMMENT '菜单id',
  remark varchar(512) NOT NULL DEFAULT '' COMMENT '备注',
  createTime datetime NOT NULL COMMENT '创建时间',
  updateTime datetime NOT NULL COMMENT '更新时间',
  PRIMARY KEY (id),
  UNIQUE INDEX UK_code (code)
  )
  COMMENT '按钮表'
  ENGINE=INNODB
  DEFAULT CHARSET=utf8;