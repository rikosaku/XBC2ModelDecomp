﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace XBC2ModelDecomp
{
    public class Structs
    {
        //wismt
        public struct MSRD
        {
            public int Version;
            public int HeaderSize;
            public int MainOffset;

            public int Tag;
            public int Revision;

            public int DataItemsCount;
            public int DataItemsOffset;
            public int FileCount;
            public int TOCOffset;

            public byte[] Unknown1; //0x1C long

            public int TextureIdsCount;
            public int TextureIdsOffset;
            public int TextureCountOffset;

            public MSRDDataItem[] DataItems;
            public MSRDTOC[] TOC;

            public short[] TextureIds;
            public int TextureCount;
            public int TextureChunkSize;
            public int Unknown2; //texture related
            public int TextureStringBufferOffset;
            public MSRDTextureInfo[] TextureInfo;
            public string[] TextureNames;
        }

        public enum MSRDDataItemTypes : ushort
        {
            Model = 0,
            ShaderBundle,
            CachedTexture,
            Texture
        }

        public struct MSRDDataItem
        {
            public int Offset;
            public int Size;
            public short id1;
            public MSRDDataItemTypes Type;
        }

        public struct MSRDTOC
        {
            public int CompSize;
            public int FileSize;
            public int Offset;

            public MemoryStream Data;
        }

        public struct MSRDTexture
        {
            public int Size;
            public int Offset;
            public string Name;
        }

        public struct MSRDTextureInfo
        {
            public int Unknown1;
            public int Size;
            public int Offset;
            public int StringOffset;
        }


        //wismt file0
        public struct Mesh
        {
            public int VertexTableOffset;
            public int VertexTableCount;
            public int FaceTableOffset;
            public int FaceTableCount;

            public byte[] Reserved1; //0xC long

            public int UnknownOffset1;
            public int UnknownOffset2;
            public int UnknownOffset2Count;

            public int KindaMorphDataOffset;
            public int DataSize;
            public int DataOffset;
            public int ExtraDataVoxOffset;
            public int ExtraDataOffset;

            public byte[] Reserved2; //0x14 long

            public MeshVertexTable[] VertexTables;
            public MeshFaceTable[] FaceTables;

            public byte[] Reserved3; //0x30 long

            public List<MeshVertexDescriptor> VertexDescriptors;

            public MeshMorphData MorphData;
        }

        public struct MeshVertexTable
        {
            public int DataOffset;
            public int DataCount;
            public int BlockSize;

            public int DescOffset;
            public int DescCount;

            public byte[] Unknown1; //0xC long

            public MeshVertexDescriptor[] Descriptors; //not in struct

            public MeshWeightManager WeightManager;
        }

        public struct MeshFaceTable
        {
            public int Offset;
            public int Count;

            public byte[] Unknown1; //0xC long
        }

        public struct MeshVertexDescriptor
        {
            public short Type;
            public short Size;
        }

        public struct MeshMorphData
        {
            public int WeightManagerCount;
            public int WeightManagerOffset;

            public short Unknown1;
            public short Unknown2;

            public int Offset02;

            public MeshWeightManager[] WeightManagers;
        }

        public struct MeshWeightManager
        {
            public int Unknown1;
            public int Offset;
            public int Count;

            public byte[] Unknown2; //0x11 long
            public byte LOD;
            public byte[] Unknown3; //0xA long
        }


        //wimdo
        public struct MXMD
        {
            public int Version;

            public int ModelStructOffset;
            public int MaterialsOffset;

            public int Unknown1;

            public int VertexBufferOffset;
            public int ShadersOffset;
            public int CachedTexturesTableOffset;
            public int Unknown2;
            public int UncachedTexturesTableOffset;

            public byte[] Unknown3; //0x28 long

            public MXMDModelStruct ModelStruct;
        }

        public struct MXMDModelStruct
        {
            public int Unknown1;
            public Vector3 BoundingBoxStart;
            public Vector3 BoundingBoxEnd;
            public int MeshesOffset;
            public int Unknown2;
            public int Unknown3;
            public int NodesOffset;

            public byte[] Unknown4; //0x54 long

            public int MorphControllersOffset;
            public int MorphNamesOffset;

            public MXMDMorphControls MorphControls;

            public MXMDMorphNames MorphNames;

            public MXMDMeshes Meshes;

            public MXMDNodes Nodes;
        }

        public struct MXMDMorphControls
        {
            public int TableOffset;
            public int Count;

            public byte[] Unknown2; //0x10 long

            public MXMDMorphControl[] Controls;
        }

        public struct MXMDMorphControl
        {
            public int NameOffset1;
            public int NameOffset2;

            public byte[] Unknown1; //0x14 long

            public string Name; //not in real struct
        }

        public struct MXMDMorphNames
        {
            public int TableOffset;
            public int Count;

            public byte[] Unknown2; //0x20 long

            public MXMDMorphName[] Names;
        }

        public struct MXMDMorphName
        {
            public int NameOffset;
            public int Unknown1;
            public int Unknown2;
            public int Unknown3;

            public string Name; //not in real struct
        }

        public struct MXMDMeshes
        {
            public int TableOffset;
            public int TableCount;
            public int Unknown1;

            public Vector3 BoundingBoxStart;
            public Vector3 BoundingBoxEnd;
            public float BoundingRadius;

            public MXMDMesh[] Meshes;
        }

        public struct MXMDMesh
        {
            public int ID;

            public int Descriptor;
            public int WeightBind; //not in struct

            public short VTBuffer;
            public short UVFaces;

            public short Unknown1;
            public short MaterialID;
            public byte[] Unknown2; //0xC long
            public short Unknown3;

            public short LOD;
            public int Unknown4;

            public byte[] Unknown5;
        }

        public struct MXMDNodes
        {
            public int BoneCount;
            public int BoneCount2;

            public int NodeIdsOffset;
            public int NodeTmsOffset;

            public MXMDNode[] Nodes;
        }

        public struct MXMDNode
        {
            public int NameOffset;
            public float Unknown1;
            public int Unknown2;

            public int ID;
            public int Unknown3;
            public int Unknown4;

            public string Name; //not in struct

            public Quaternion Scale;
            public Quaternion Rotation;
            public Quaternion Position;

            public Quaternion ParentTransform;
        }


        //arc, mot
        public struct SAR1
        {
            public int FileSize;
            public int Version;
            public int NumFiles;
            public int TOCOffset;
            public int DataOffset;
            public int Unknown1;
            public int Unknown2;
            public string Path; //0x80 chars

            public SARTOC[] TOCItems;
            public SARBC[] BCItems;

            public SARBC ItemBySearch(string search)
            {
                return BCItems[Array.FindIndex(TOCItems, x => x.Filename.Contains(search))];
            }
        }

        public struct SARTOC
        {
            public int Offset;
            public int Size;
            public int Unknown1;
            public string Filename; //0x34 chars
        }

        public struct SARBC
        {
            public int BlockCount;
            public int FileSize;
            public int PointerCount;
            public int OffsetToData; //starts from blockcount, not magic

            public MemoryStream Data;
        }


        //arc
        public struct SKEL
        {
            public int Unknown1;
            public int Unknown2;

            public SKELTOC[] TOCItems;
            public short[] Parents;
            public SKELNodes[] Nodes;
            public SKELTransforms[] Transforms;
        }

        public struct SKELTOC
        {
            public int Offset;
            public int Unknown1;
            public int Count;
            public int Unknown2;
        }

        public struct SKELNodes
        {
            public int Offset;
            public byte[] Unknown1; //0xC long
            public string Name; //not in struct
        }

        public struct SKELTransforms
        {
            public Quaternion Position;
            public Quaternion Rotation;
            public Quaternion Scale;
        }
    }
}
