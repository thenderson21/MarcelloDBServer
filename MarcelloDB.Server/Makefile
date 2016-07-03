
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/MarcelloDB.Server.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

MARCELLODB_SERVER_EXE_MDB_SOURCE=bin/Debug/MarcelloDB.Server.exe.mdb
MARCELLODB_SERVER_EXE_MDB=$(BUILD_DIR)/MarcelloDB.Server.exe.mdb
MARCELLODB_DLL_SOURCE=../packages/MarcelloDB.0.4.0/lib/net45/MarcelloDB.dll
MARCELLODB_NETFX_DLL_SOURCE=../packages/MarcelloDB.0.4.0/lib/net45/MarcelloDB.netfx.dll
COMMANDLINE_DLL_SOURCE=../packages/CommandLineParser.1.9.71/lib/net45/CommandLine.dll
NEWTONSOFT_JSON_DLL_SOURCE=../packages/Newtonsoft.Json.9.0.1/lib/net45/Newtonsoft.Json.dll

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/MarcelloDB.Server.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

MARCELLODB_SERVER_EXE_MDB=
MARCELLODB_DLL_SOURCE=../packages/MarcelloDB.0.4.0/lib/net45/MarcelloDB.dll
MARCELLODB_NETFX_DLL_SOURCE=../packages/MarcelloDB.0.4.0/lib/net45/MarcelloDB.netfx.dll
COMMANDLINE_DLL_SOURCE=../packages/CommandLineParser.1.9.71/lib/net45/CommandLine.dll
NEWTONSOFT_JSON_DLL_SOURCE=../packages/Newtonsoft.Json.9.0.1/lib/net45/Newtonsoft.Json.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(MARCELLODB_SERVER_EXE_MDB) \
	$(MARCELLODB_DLL) \
	$(MARCELLODB_NETFX_DLL) \
	$(COMMANDLINE_DLL) \
	$(NEWTONSOFT_JSON_DLL)  


RESGEN=resgen2

MARCELLODB_DLL = $(BUILD_DIR)/MarcelloDB.dll
MARCELLODB_NETFX_DLL = $(BUILD_DIR)/MarcelloDB.netfx.dll
COMMANDLINE_DLL = $(BUILD_DIR)/CommandLine.dll
NEWTONSOFT_JSON_DLL = $(BUILD_DIR)/Newtonsoft.Json.dll

FILES = \
	Main.cs \
	Properties/AssemblyInfo.cs \
	Server.cs \
	Application.cs \
	Constants/Info.cs \
	Options.cs \
	Constants/DefaultOptions.cs \
	Models/_User.cs \
	Data/DataCollectionChangedEventArgs.cs \
	Data/Database.cs \
	Helpers/ObjectExtension.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	packages.config 

REFERENCES =  \
	System

DLL_REFERENCES =  \
	../../../../../../MarcelloDB \
	../../../../../../MarcelloDB.netfx \
	../../../../../../CommandLine \
	../../../../../../Newtonsoft.Json

CLEANFILES = $(PROGRAMFILES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,MARCELLODB_DLL))
$(eval $(call emit-deploy-target,MARCELLODB_NETFX_DLL))
$(eval $(call emit-deploy-target,COMMANDLINE_DLL))
$(eval $(call emit-deploy-target,NEWTONSOFT_JSON_DLL))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MARCELLODB_SERVER_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MARCELLODB_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MARCELLODB_NETFX_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(COMMANDLINE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(NEWTONSOFT_JSON_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MARCELLODB_SERVER_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MARCELLODB_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MARCELLODB_NETFX_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(COMMANDLINE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(NEWTONSOFT_JSON_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
